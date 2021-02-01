using System.Collections.Generic;
using Seismic.Clean.Domain.Common.Exceptions;

namespace Seismic.Clean.Domain.Common.ValueObjects
{
    public class ContentFormat
    {
        public string Format { get; private set; }

        public static ContentFormat Powerpoint => new ContentFormat("PPTX");
        public static ContentFormat Word => new ContentFormat("DOCX");
        public static ContentFormat Excel => new ContentFormat("XLSX");
        public static ContentFormat Text => new ContentFormat("TXT");
        public static ContentFormat Png => new ContentFormat("PNG");
        public static ContentFormat Jpeg => new ContentFormat("JPEG");
        public static ContentFormat Mp3 => new ContentFormat("MP3");
        public static ContentFormat Mp4 => new ContentFormat("MP4");

        private ContentFormat() { }

        private ContentFormat(string format)
        {
            Format = format;
        }

        public static ContentFormat From(string format)
        {
            var contentFormat = new ContentFormat(format.ToUpper());
            if (!IsSupportedFormat(contentFormat))
            {
                throw new InvalidContentFormatException(format);
            }

            return contentFormat;
        }

        private static bool IsSupportedFormat(ContentFormat contentFormat)
        {
            var supportedFormats = new HashSet<ContentFormat>
            {
                ContentFormat.Powerpoint,
                ContentFormat.Word,
                ContentFormat.Excel,
                ContentFormat.Text,
                ContentFormat.Png,
                ContentFormat.Jpeg,
                ContentFormat.Mp3,
                ContentFormat.Mp4
            };

            return supportedFormats.Contains(contentFormat);
        }

        public override bool Equals(object obj)
        {
            return obj is ContentFormat format &&
                   Format == format.Format;
        }

        public override int GetHashCode()
        {
            return 50578242 + EqualityComparer<string>.Default.GetHashCode(Format);
        }
    }
}