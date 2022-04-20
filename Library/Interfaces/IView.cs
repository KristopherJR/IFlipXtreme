//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;

namespace Library
{
    /// <summary>
    /// IView Interface
    /// </summary>
    public interface IView : ISubscriber
    {
        Action<ICommand> ExecutePointer { set; }

        // DECLARE a get Property for "_galleryView":
        IGalleryView GalleryView { get; }

        // DECLARE a get Property for "_editor":
        IImageView ImageView { get; }

        /// <summary>
        /// StartApp: Starts the application by running the "_gallery".
        /// </summary>
        void StartApp();

        /// <summary>
        /// ToggleForms: Toggles the Visibility of the "_gallery" and "_editor":
        /// </summary>
        void ToggleForms();
    }
}