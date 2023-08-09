using System.Text.RegularExpressions;

namespace Portfolio.MechanistTower.Manipulators
{
    public class EchoShaper : IEchoShaper
    {
        public string AugmentRunicNaming(string fileName)
        {
            var uniqueId = Guid.NewGuid().ToString();

            var pattern = @"[^.]+$";
            var fileType = Regex.Match(fileName, pattern).ToString();

            fileName = Regex.Replace(fileName, $@"\b.{fileType}\b", "");
            fileName = fileName.Replace(" ", String.Empty);

            var augmentedRune = $"{fileName}-{uniqueId}.{fileType}";

            return augmentedRune;
        }

        public Stream ShapeEcho(IFormFile file, int height)
        {
            using var echo = Image.Load(file.OpenReadStream());
            var stream = new MemoryStream();

            echo.Mutate(x => x.Resize(0, height));

            switch (file.ContentType)
            {
                case "image/jpeg":
                    echo.SaveAsJpeg(stream);
                    break;

                case "image/png":
                    echo.SaveAsPng(stream);
                    break;

                case "image/bmp":
                    echo.SaveAsBmp(stream);
                    break;

                case "image/gif":
                    echo.SaveAsGif(stream);
                    break;

                default:
                    throw new Exception("invalid file type");
            }

            stream.Position = 0;
            return stream;
        }
    }
}