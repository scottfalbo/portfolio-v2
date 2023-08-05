using Portfolio.MechanistTower.Entities;

namespace MechanistTowerTrials.SorcerySupport
{
    internal class OculusEchoScribe
    {
        private string _altText = "alt-text";
        private DateTimeOffset _createdDateTime = DateTimeOffset.Now;
        private bool _display = true;
        private string _imageUrl = "test-url";
        private bool _isForSale;
        private string _medium;
        private string _name;
        private decimal _price;
        private string _size;
        private string _thumbnailUrl = "thumbnail-url";

        public OculusEchoScribe WithAltText(string altText)
        {
            _altText = altText;
            return this;
        }

        public OculusEchoScribe WithCreatedDateTime(DateTimeOffset createdDateTime)
        {
            _createdDateTime = createdDateTime;
            return this;
        }

        public OculusEchoScribe WithDisplay(bool display)
        {
            _display = display;
            return this;
        }

        public OculusEchoScribe WithImageUrl(string imageUrl)
        {
            _imageUrl = imageUrl;
            return this;
        }

        public OculusEchoScribe WithIsForSale(bool isForSale)
        {
            _isForSale = isForSale;
            return this;
        }

        public OculusEchoScribe WithMedium(string medium)
        {
            _medium = medium;
            return this;
        }

        public OculusEchoScribe WithName(string name)
        {
            _name = name;
            return this;
        }

        public OculusEchoScribe WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public OculusEchoScribe WithSize(string size)
        {
            _size = size;
            return this;
        }

        public OculusEchoScribe WithThumbnailUrl(string thumbnailUrl)
        {
            _thumbnailUrl = thumbnailUrl;
            return this;
        }

        public FleshRite BuildFleshRite()
        {
            var fleshRite = new FleshRite()
            {
                AltText = _altText,
                CreatedDateTime = _createdDateTime,
                Display = _display,
                ImageUrl = _imageUrl,
                Name = _name,
                ThumbnailUrl = _thumbnailUrl
            };

            return fleshRite;
        }
    }
}