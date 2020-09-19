using System;

namespace NAWD.Utilities
{
    internal static class ParsingUtility
    {
        private static void Resize(ref string[] array)
        {
            int i = array.Length;
            Array.Resize(ref array, i + 1);
            array[i] = null;
        }

        /// <summary>
        /// 현재 인스턴스를 지정한 두 문자열을 이용하여 파싱하고 그 결과를 반환합니다. 단, 해당하는 결과가 많을 경우에는 제일 처음 나타나는 값을 반환합니다.
        /// </summary>
        /// <param name="text">파싱할 문자열입니다.</param>
        /// <param name="start">시작 문자열입니다.</param>
        /// <param name="end">종료 문자열입니다.</param>
        /// <returns>파싱된 문자열.</returns>
        internal static string SingleParse(this string text, string start, string end)
        {
            string result = string.Empty;
            result = text.Substring(text.IndexOf(start) + start.Length);
            result = result.Substring(0, result.IndexOf(end));
            return result;
        }

        /// <summary>
        /// 현재 인스턴스를 지정한 두 문자열을 이용하여 역순으로 파싱하고 그 결과를 반환합니다. 단, 해당하는 결과가 많을 경우에는 제일 처음 나타나는 값을 반환합니다.
        /// </summary>
        /// <param name="text">파싱할 문자열입니다.</param>
        /// <param name="start">시작 문자열입니다.</param>
        /// <param name="end">종료 문자열입니다.</param>
        /// <returns>파싱된 문자열.</returns>
        internal static string LastSingleParse(this string text, string start, string end)
        {
            string result = string.Empty;
            result = text.Substring(text.LastIndexOf(start) + start.Length);
            result = result.Substring(0, result.IndexOf(end));
            return result;
        }

        /// <summary>
        /// 현재 인스턴스를 지정한 두 문자열을 이용하여 전부 파싱하고 그 결과를 배열로 반환합니다.
        /// </summary>
        /// <param name="text">파싱할 문자열입니다.</param>
        /// <param name="strStart">시작 문자열입니다.</param>
        /// <param name="strEnd">종료 문자열입니다.</param>
        /// <returns>파싱된 문자열.</returns>
        internal static string[] MultipleParse(this string text, string start, string end)
        {
            string source = text;
            string[] result = { null };
            int Count = 0;

            while (source.IndexOf(start) > -1)
            {
                Resize(ref result);

                source = source.Substring(source.IndexOf(start) + start.Length);

                if (source.IndexOf(end) != -1)
                {
                    result[Count] = source.Substring(0, source.IndexOf(end));
                }
                else
                {
                    return result;
                }

                Count++;
            }
            return result;
        }
    }
}
