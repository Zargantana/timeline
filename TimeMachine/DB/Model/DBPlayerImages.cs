using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TimeMachine.DB.Model
{
    public class DBPlayerImages: ICloneable
    {
        public Image[] PersonajeAnimationLeft { get; set; }
        public Image[] PersonajeAnimationRight { get; set; }
        public Image[] PersonajeAnimationUp { get; set; }
        public Image[] PersonajeAnimationDown { get; set; }
        public Image PersonajeLeft { get; set; }
        public Image PersonajeRight { get; set; }
        public Image PersonajeUp { get; set; }
        public Image PersonajeDown { get; set; }

        private Image[] copyCollection(Image[] collection)
        {
            Image[] _newCopy = new Image[collection.Length];
            for (int i = 0; i < collection.Length; i++)
            {
                _newCopy[i] = (Image)collection[i].Clone();
            }
            return _newCopy;
        }

        public object Clone()
        {
            DBPlayerImages _newCopy = new DBPlayerImages();

            _newCopy.PersonajeAnimationDown = copyCollection(this.PersonajeAnimationDown);
            _newCopy.PersonajeAnimationUp = copyCollection(this.PersonajeAnimationUp);
            _newCopy.PersonajeAnimationLeft = copyCollection(this.PersonajeAnimationLeft);
            _newCopy.PersonajeAnimationRight = copyCollection(this.PersonajeAnimationRight);
            _newCopy.PersonajeDown = (Image)this.PersonajeDown.Clone();
            _newCopy.PersonajeUp = (Image)this.PersonajeUp.Clone();
            _newCopy.PersonajeLeft = (Image)this.PersonajeLeft.Clone();
            _newCopy.PersonajeRight = (Image)this.PersonajeRight.Clone();

            return _newCopy;
        }
    }

    public class DBPlayersImages : Dictionary<string, DBPlayerImages>, ICloneable
    {
        public object Clone()
        {
            DBPlayersImages _newCopy = new DBPlayersImages();

            foreach (KeyValuePair<string, DBPlayerImages> _pointer in this)
            {
                _newCopy.Add(_pointer.Key, (DBPlayerImages)_pointer.Value.Clone());
            }
            return _newCopy;
        }
    }
}
