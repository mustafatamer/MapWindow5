using System;
using System.Collections.Generic;
using System.Text;

namespace Equin.ApplicationFramework
{
    /// <summary>
    /// Bunu test etmek için genel bir yöntemi tanýmlar. Bir öðeye dahil edilmelidir. <see cref="BindingListView&lt;T&gt;"/>.
    /// </summary>
    /// <typeparam name="T">Filtrelenecek öðenin türü.</typeparam>
    public interface IItemFilter<T>
    {
        /// <summary>
        /// Öðe dahil edilmesi gerektiðinde testler.
        /// </summary>
        /// <param name="item">Test edilecek öðe.</param>
        /// <returns>Öðe dahil edilmesi gerekiyorsa, aksi halde yanlýþ.</returns>
        bool Include(T item);
    }

    /// <summary>
    /// A dummy filter that is used when no filter is needed.
    /// It simply includes any and all items tested.
    /// </summary>
    public class IncludeAllItemFilter<T> : IItemFilter<T>
    {
        public bool Include(T item)
        {
            // All items are to be included.
            // So always return true.
            return true;
        }

        public override string ToString()
        {
            return Properties.Resources.NoFilter;
        }

        #region Singleton Accessor

        private static IncludeAllItemFilter<T> _instance;

        /// <summary>
        /// Gets the singleton instance of <see cref="IncludeAllItemFilter&lt;T&gt;"/>.
        /// </summary>
        public static IncludeAllItemFilter<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IncludeAllItemFilter<T>();
                }
                return _instance;
            }
        }

        #endregion
    }

    /// <summary>
    /// A filter that uses a user-defined <see cref="Predicate&lt;T&gt;"/> to test items for inclusion in <see cref="BindingListView&lt;T&gt;"/>.
    /// </summary>
    public class PredicateItemFilter<T> : IItemFilter<T>
    {
        /// <summary>
        /// Creates a new <see cref="PredicateItemFilter&lt;T&gt;"/> that uses the specified <see cref="Predicate&lt;T&gt;"/> and default name.
        /// </summary>
        /// <param name="includeDelegate">The <see cref="Predicate&lt;T&gt;"/> used to test items.</param>
        public PredicateItemFilter(Predicate<T> includeDelegate)
            : this(includeDelegate, null)
        {
            // The other constructor is called to do the work.
        }

        /// <summary>
        /// Creates a new <see cref="PredicateItemFilter&lt;T&gt;"/> that uses the specified <see cref="Predicate&lt;T&gt;"/>.
        /// </summary>
        /// <param name="includeDelegate">The <see cref="PredicateItemFilter&lt;T&gt;"/> used to test items.</param>
        /// <param name="name">The name used for the ToString() return value.</param>
        public PredicateItemFilter(Predicate<T> includeDelegate, string name)
        {
            // We don't allow a null string. Use the default instead.
            _name = name ?? defaultName;
            if (includeDelegate != null)
            {
                _includeDelegate = includeDelegate;
            }
            else
            {
                throw new ArgumentNullException("includeDelegate", Properties.Resources.IncludeDelegateCannotBeNull);
            }
        }

        private Predicate<T> _includeDelegate;
        private string _name;
        private readonly string defaultName = Properties.Resources.PredicateFilter;

        public bool Include(T item)
        {
            return _includeDelegate(item);
        }

        public override string ToString()
        {
            return _name;
        }
    }

    // TODO: Implement this class
    /*
    public class ExpressionItemFilter<T> : IItemFilter<T>
    {
        public ExpressionItemFilter(string expression)
        {
            // TODO: Parse expression into predicate
        }

        public bool Include(T item)
        {
            // TODO: use expression...
            return true;
        }
    }
    */

    // TODO: Implement this class
    /*
    public class CSharpItemFilter<T> : IItemFilter<T>
    {
        public CSharpItemFilter(string filterSourceCode)
        {
            
        }

        public bool Include(T item)
        {
            // TODO: implement this method...
            return true;
        }
    }
    */
}
