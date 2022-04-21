//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Library
{
    /// <summary>
    /// IGalleryView Interface
    /// </summary>
    public interface IGalleryView
    {
        // DECLARE a set property for _toggleFormPointer. Call it "ToggleFormPointer":
        Action ToggleFormPointer { set; }

        // DECLARE a get property for _thumbnailList. Call it "ThumbnailList":
        List<Image> ThumbnailList { get; }

        // DECLARE a get-set property for _commands. Call it "Commands":
        Dictionary<string, ICommand> Commands { get; set; }

        // DECLARE a set property for _executePointer. Call it "ExecutePointer":
        Action<ICommand> ExecutePointer { set; }

        /// <summary>
        /// InjectThumbnails: Updates the Thumbnail image collection and refreshes them in the GUI.
        /// </summary>
        /// <param name="pThumbs">A List containing the new image thumbnail collection.</param>
        void InjectThumbnails(List<Image> pThumbs);
    }
}