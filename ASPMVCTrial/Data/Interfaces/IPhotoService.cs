using CloudinaryDotNet.Actions;
using Humanizer.Localisation.TimeToClockNotation;

namespace ASPMVCTrial.Data.Interfaces
{
    public interface IPhotoService
    {
        public Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        public Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
