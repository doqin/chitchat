using Client.Properties;
using Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Extensions
{
    internal class Helpers
    {
        public static Image GetProfilePicture()
        {
            if (!string.IsNullOrEmpty(ConfigManager.Current!.ProfileImagePath) && Path.Exists(Path.Combine("Cached", ConfigManager.Current!.ProfileImagePath)))
            {
                return CorrectImageOrientation(Image.FromFile(Path.Combine("Cached", ConfigManager.Current!.ProfileImagePath)));
            }
            else
            {
                return Resources.user;
            }
        }

        public static Image GetProfilePicture(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath) && Path.Exists(Path.Combine("Cached", imagePath)))
            {
                return CorrectImageOrientation(Image.FromFile(Path.Combine("Cached", imagePath)));
            }
            else
            {
                return Resources.user;
            }
        }

        public static Image GetProfilePicture(
            TcpClient tcpClient, 
            Dictionary<string, Tuple<TaskCompletionSource<string>, string>> pendingFetches, 
            string imagePath
            ) 
        {
            if (System.IO.File.Exists(Path.Combine("Cached", imagePath)))
            {
                return CorrectImageOrientation(Image.FromFile(Path.Combine("Cached", imagePath)));
            }
            else
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine($"Fetching profile image: {imagePath}");
                    var request = new Wrapper
                    {
                        Type = Types.GetFile,
                        Payload = imagePath
                    };
                    string requestJson = JsonSerializer.Serialize(request);
                    // Fetch the profile image data from the server
                    var filePath = Protocol.File.FetchFile(tcpClient, pendingFetches, imagePath, Path.Combine("Cached", imagePath), requestJson);
                    if (string.IsNullOrEmpty(filePath) || (!string.IsNullOrEmpty(filePath) && filePath == "Not found"))
                    {
                        throw new FileNotFoundException("Profile image not found on server.");
                    }
                    // Load image
                    return CorrectImageOrientation(Image.FromFile(filePath));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error fetching profile image: {ex.Message}");
                }
            }
            return Resources.user;
        }

        /// <summary>
        /// Corrects the orientation of an image based on its EXIF data
        /// </summary>
        /// <param name="image">The image to correct</param>
        /// <returns>The corrected image</returns>
        public static Image CorrectImageOrientation(Image image)
        {
            const int ExifOrientationTagId = 0x0112; // EXIF orientation tag

            if (!image.PropertyIdList.Contains(ExifOrientationTagId))
                return image;

            var property = image.GetPropertyItem(ExifOrientationTagId);
            int orientation = BitConverter.ToUInt16(property.Value, 0);

            switch (orientation)
            {
                case 2:
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    break;
                case 3:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 4:
                    image.RotateFlip(RotateFlipType.Rotate180FlipX);
                    break;
                case 5:
                    image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    break;
                case 6:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 7:
                    image.RotateFlip(RotateFlipType.Rotate270FlipX);
                    break;
                case 8:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }

            // Remove the EXIF orientation tag to prevent double-rotation
            image.RemovePropertyItem(ExifOrientationTagId);

            return image;
        }
    }
}
