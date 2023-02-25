﻿using System.Linq;

namespace Haxee.MQTTConsumer.Services
{
    public class HelperService
    {
        public static bool ValidMenuOption(List<int> validOptions, int option)
        {
            foreach (int o in validOptions)
                if (o == option)
                    return true;

            return false;
        }

        public static bool ValidateYear(string year)
        {
            return int.TryParse(year, out int y);
        }

        public static bool ValidateIp(string a)
        {

            List<string> ip = a.Split('.').ToList();

            if (ip.Count != 4)
                return false;

            foreach (string i in ip)
            {
                if (!int.TryParse(i, out int current))
                    return false;

                if (current < 0 || current > 255)
                    return false;
            }

            return true;
        }

        public static bool ValidatePort(string p)
        {

            if (!int.TryParse(p, out int port))
                return false;

            if (port > 49151)
                return false;

            return true;
        }

        public static bool ValidateTopic(string topic)
        {
            if (topic == String.Empty || topic.Length < 3)
                return false;

            if (topic.First().Equals('/') || topic.First().Equals('$'))
                return false;

            if (!(topic.Substring(topic.Length - 2, 2)).Equals("/#"))
                return false;

            List<string> forbiddenChars = new List<string>(){ "#", "+", ">", "*", "$", "//", "\\" };

            foreach (string c in forbiddenChars)
            {
                if (c == "#" && topic.Contains(c))
                {
                    if (topic.Count(x => x == '#') > 1)
                        return false;

                    if (topic.Last() != '#')
                        return false;
                }
                else if (topic.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidateCurrentYearSetup(string year, string topic, string port, string ip)
        {
            bool valid = true;

            if (!ValidateYear(year))
            {
                valid = false;
                DrawService.DrawErrorMessage("YEAR not valid");
            }

            if (!ValidateTopic(topic))
            {
                valid = false;
                DrawService.DrawErrorMessage("TOPIC not valid");
            }

            if (!ValidatePort(port))
            {
                valid = false;
                DrawService.DrawErrorMessage("PORT not valid");
            }

            if (!ValidateIp(ip))
            {
                valid = false;
                DrawService.DrawErrorMessage("IP not valid");
            }
            return valid;
        }
    }
}