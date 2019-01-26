namespace AdventOfCode2016.Day05
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Day05Solver
    {
        public string PuzzleOne(string input)
        {
            var password = string.Empty;

            var index = 0L;

            while (password.Length < 8)
            {
                var text = $"{input}{index}";

                var md5 = CreateMD5(text);

                if (md5.StartsWith("00000"))
                {
                    password += md5[5];
                }

                index++;
            }

            return password.ToLower();
        }

        public string PuzzleTwo(string input)
        {
            var password = string.Empty;

            var index = 0L;

            var positions = new SortedDictionary<int, char>();

            while (positions.Count < 8)
            {
                var text = $"{input}{index}";

                var md5 = CreateMD5(text);

                if (md5.StartsWith("00000"))
                {
                    if (int.TryParse(md5[5].ToString(), out var position)
                        && 0 <= position && position < 8)
                    {
                        if (!positions.ContainsKey(position))
                        {
                            positions.Add(position, md5[6]);
                        }
                    }
                }

                index++;
            }

            return string.Join("", positions.Values).ToLower();
        }

        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }
    }
}