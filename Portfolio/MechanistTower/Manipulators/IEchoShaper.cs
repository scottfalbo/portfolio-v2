using System.Text.RegularExpressions;

namespace Portfolio.MechanistTower.Manipulators
{
    public interface IEchoShaper
    {
        public Stream ShapeEcho(IFormFile file, int height);

        public string AugmentRunicNaming(string fileName);
    }
}