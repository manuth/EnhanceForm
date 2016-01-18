using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnhanceForm
{
    /// <summary>
    /// Represents a set of buttons
    /// </summary>
    public class ButtonCollection : CollectionBase
    {
        /// <summary>
        /// Returns or sets the element at the specified index
        /// </summary>
        /// <param name="index">The zero-based index of the element</param>
        public Button this[int index]
        {
            get
            {
                return (List[index] as Button);
            }

            set
            {
                List[index] = value;
            }
        }

        /// <summary>
        /// Returns a value, which describes, whether the IList is read-only
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return List.IsReadOnly;
            }
        }

        /// <summary>
        /// Adds the given button to the list
        /// </summary>
        /// <param name="button">Defines the button to add</param>
        /// <exception cref="NotSupportedException" />
        public void Add(Button button)
        {
            List.Add(button);
        }

        /// <summary>
        /// Returns whether the IList contains a specific value
        /// </summary>
        /// <param name="item">The item to find</param>
        /// <returns>Describes whether the specified value was found</returns>
        public bool Contains(Button item)
        {
            return List.Contains(item);
        }

        /// <summary>
        /// Copys the collection's elements to a specific array, starting at a specified index
        /// </summary>
        /// <param name="array">Defines the array to copy the elements to</param>
        /// <param name="arrayIndex">Defines the start-index</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public void CopyTo(Button[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Decides the index of a certain item
        /// </summary>
        /// <param name="item">The item to search</param>
        public int IndexOf(Button item)
        {
            return List.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item into the list
        /// </summary>
        /// <param name="index">The zero-based index to insert the item</param>
        /// <param name="item">The item to insert</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="NotSupportedException" />
        /// <exception cref="NullReferenceException" />
        public void Insert(int index, Button item)
        {
            List.Insert(index, item);
        }

        /// <summary>
        /// Removes the first occurance of a specific item
        /// </summary>
        /// <param name="item">The item to remove</param>
        public void Remove(Button item)
        {
            List.Remove(item);
        }
    }
}
