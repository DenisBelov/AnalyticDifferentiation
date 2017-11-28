using System.IO;

namespace KursProject1 {
    public static class FileReader {
        public static string GetExpressionFromFile(string filePath)
        {
            var stream = new StreamReader(new FileStream(filePath, FileMode.Open));
            string expression = stream.ReadToEnd();
            expression.Replace(" ", string.Empty);
            return expression;
        }
    }
}
