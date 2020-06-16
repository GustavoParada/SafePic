using Domain.Core.Bus;
using SharePic.Application.Interfaces;
using SharePic.Domain.Commands;
using SharePic.Domain.Interfaces;
using SharePic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace SharePic.Application.Services
{
    public class SharePicService : ISharePicService
    {
        private readonly IEventBus _bus;
        private readonly ISharePicRepository _sharePicRepository;

        public SharePicService(IEventBus bus, ISharePicRepository sharePicRepository)
        {
            _bus = bus;
            _sharePicRepository = sharePicRepository;
        }

        public async Task<IEnumerable<SharedPic>> GetSharedByUser(Guid userId)
        {
            var imagesFromDataBase = await _sharePicRepository.GetSharedList(userId, DateTime.Now);

            var safeText = $"Gustavo Parada {DateTime.Now.ToShortDateString()}";

            foreach (var picFromDataBase in imagesFromDataBase)
            {
                var imageInBytes = Convert.FromBase64String(picFromDataBase.Base64);

                using MemoryStream ms = new MemoryStream(imageInBytes);
                Image pic = Image.FromStream(ms);

                using Font font = new Font("ArialBlack", pic.Width / safeText.Length, FontStyle.Bold);
                var safedPic = ImageHelper.Watermak(pic, safeText, font);

                using (MemoryStream m = new MemoryStream())
                {
                    safedPic.Save(m, safedPic.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    var base64String = Convert.ToBase64String(imageBytes);
                    picFromDataBase.Base64 = base64String;
                }

            }

            return imagesFromDataBase;
        }

        public async Task SharePic(Guid from, Guid to, string pic, int duration)
        {
            try
            {
                var createdSharePicCommand = new CreateSharePicCommand(from, to, pic, duration);
                await _bus.SendCommand(createdSharePicCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



    public static class ImageHelper
    {
        public static Image Watermak(Image image, string text, Font font)
        {
            using (Graphics gr = Graphics.FromImage(image))
            {
                using (StringFormat string_format = new StringFormat())
                {
                    string_format.Alignment = StringAlignment.Center;

                    int dy = (int)(gr.MeasureString("X", font).Height * 4);
                    int x = image.Width / 2;
                    int y = 20;

                    for (int i = 0; i < 7; i++)
                    {
                        string txt = text; //+ opacity.ToString();
                        using (Brush brush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
                        {
                            gr.DrawString(txt, font, brush, x, y, string_format);
                        }
                        using (Brush brush = new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
                        {
                            gr.DrawString(txt, font, brush, x - 2, y - 2, string_format);
                        }
                        y += dy;
                    }
                }

                return image;
            }
        }
    }
}
