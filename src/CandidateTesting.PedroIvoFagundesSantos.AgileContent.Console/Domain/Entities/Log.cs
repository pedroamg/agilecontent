using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Entities
{
    public class Log
    {
        private readonly char[] _split;
        private readonly StringBuilder _agoraLogBuilder;
        private readonly Dictionary<string, int> _positions;

        public Log(char[] split, StringBuilder agoraLog, Dictionary<string, int> positions)
        {
            _split = split;
            _agoraLogBuilder = agoraLog;
            _positions = positions;
        }

        public string GetAgoraLogFormat(string file)
        {
            var logLines = file.Split(_split, StringSplitOptions.RemoveEmptyEntries);
            _agoraLogBuilder.Append(GetHeaders());
            foreach (var line in logLines)
            {
                CreateNewLine();
                var fields = line.Split(' ', '|');
                foreach (var (key, value) in _positions)
                    ConvertFieldsToAgoraFormat(fields[value], key);
            }

            var formated = _agoraLogBuilder.ToString();
            return formated;
        }

        private static string GetHeaders()
        {
            return $"{LogConstants.Version} \n#Date: {DateTime.Now} \n{LogConstants.HeaderFields}";
        }

        private void CreateNewLine()
        {
            _agoraLogBuilder.Append($"\n{LogConstants.Provider} ");
        }

        private void ConvertFieldsToAgoraFormat(string line, string position)
        {
            switch (position)
            {
                case LogConstants.HttpMethod:
                    _agoraLogBuilder.Append($"{line.Replace("\"", "")} ");
                    break;
                case LogConstants.TimeTaken when decimal.TryParse(line, out _):
                    _agoraLogBuilder.Append($"{Math.Round(decimal.Parse(line, CultureInfo.InvariantCulture))} ");
                    break;
                default:
                    _agoraLogBuilder.Append($"{line} ");
                    break;
            }
        }
    }
}