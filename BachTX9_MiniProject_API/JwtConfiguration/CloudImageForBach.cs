using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.JwtConfiguration
{
    public class CloudImageForBach
    {
        public const string COUD_NAME = "vietnamenglishcore";
        public const string API_KEY = "437223111312275";
        public const string API_SECRET = "gi7VkA-DP_mVv5B3QGD-VFJr_ho";
        public async Task<string> UploadImage(string imageFile)
        {
            var url = "";
            try
            {
                if (imageFile == null)
                {
                    url = null;
                }
                else
                {
                    var account = new Account(COUD_NAME, API_KEY, API_SECRET);

                    var cloudinary = new Cloudinary(account);

                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(imageFile),
                    };
                    var uploadResult = await cloudinary.UploadAsync(uploadParams);
                    url = uploadResult.Url.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return url;
        }

    }
}
