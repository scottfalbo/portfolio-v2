using Portfolio.MechanistTower.Entities;

namespace MechanistTowerTrials.SorcerySupport
{
    internal class InfernalContractScribe
    {
        private string _altText;
        private DateTimeOffset _createdDateTime = DateTimeOffset.Now;
        private bool _display = true;
        private string _eternalSymbol;
        private string _id;
        private string _imageUrl;
        private bool _isForSale;
        private string _medium;
        private string _name;
        private string _partitionKey;
        private decimal _price;
        private string _size;
        private string _thumbnailUrl;

        public InfernalContractScribe WithAltText(string altText)
        {
            _altText = altText;
            return this;
        }

        public InfernalContractScribe WithCreatedDateTime(DateTimeOffset createdDateTime)
        {
            _createdDateTime = createdDateTime;
            return this;
        }

        public InfernalContractScribe WithDisplay(bool display)
        {
            _display = display;
            return this;
        }

        public InfernalContractScribe WithEternalSymbol(string eternalSymbol)
        {
            _eternalSymbol = eternalSymbol;
            return this;
        }

        public InfernalContractScribe WithId(string id)
        {
            _id = id;
            return this;
        }

        public InfernalContractScribe WithImageUrl(string imageUrl)
        {
            _imageUrl = imageUrl;
            return this;
        }

        public InfernalContractScribe WithIsForSale(bool isForSale)
        {
            _isForSale = isForSale;
            return this;
        }

        public InfernalContractScribe WithMedium(string medium)
        {
            _medium = medium;
            return this;
        }

        public InfernalContractScribe WithName(string name)
        {
            _name = name;
            return this;
        }

        public InfernalContractScribe WithPartitionKey(string partitionKey)
        {
            _partitionKey = partitionKey;
            return this;
        }

        public InfernalContractScribe WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public InfernalContractScribe WithSize(string size)
        {
            _size = size;
            return this;
        }

        public InfernalContractScribe WithThumbnailUrl(string thumbnailUrl)
        {
            _thumbnailUrl = thumbnailUrl;
            return this;
        }

        public InfernalContract Build()
        {
            var infernalContract = new InfernalContract()
            {
                AltText = _altText,
                CreatedDateTime = _createdDateTime,
                Display = _display,
                EternalSymbol = _eternalSymbol,
                Id = _id,
                ImageUrl = _imageUrl,
                IsForSale = _isForSale,
                Medium = _medium,
                Name = _name,
                PartitionKey = _partitionKey,
                Price = _price,
                Size = _size,
                ThumbnailUrl = _thumbnailUrl
            };

            return infernalContract;
        }
    }
}