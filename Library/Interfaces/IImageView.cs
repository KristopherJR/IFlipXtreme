//Authors: Alfie Baker-James, Teodor-Cristian Lutoiu, Kris Randle
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Library
{
    /// <summary>
    /// IImageView Interface
    /// </summary>
    public interface IImageView
    {
        // DECLARE a set property for "_image".  Call it "Image".
        Image Image
        { set; }

        // DECLARE a set property for "_toggleFormPointer".  Call it "ToggleFormPointer".
        Action ToggleFormPointer { set; }

        // DECLARE a set property for "_executePointer".  Call it "ExecutePointer".
        Action<ICommand> ExecutePointer { set; }

        // DECLARE a get-set property for "_commands".  Call it "Commands".
        Dictionary<string, ICommand> Commands { get; set; }
    }
}