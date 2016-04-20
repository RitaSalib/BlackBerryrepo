using BlackberryRepo.Portable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BlackberryRepo.Converters
{
    public class ItemTypeContainerStyleSelector : StyleSelector
    {
        public Style CplusplusStyle { get; set; }
        public Style JavaStyle { get; set; }
        public Style CStyle { get; set; }
        public Style JavaScriptStyle { get; set; }
        public Style CsharpStyle { get; set; }
        public Style RubyStyle { get; set; }
        public Style XSLTStyle { get; set; }

        protected override Style SelectStyleCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            RepoItem repo = (RepoItem)item;
            return GetItemStyle(repo);
        }

        private Style GetItemStyle(RepoItem item)
        {
            Style style = CplusplusStyle;

            switch (item.language)
            {

                case "C++":
                    style = CplusplusStyle;
                    break;
                case "Java":
                    style = JavaStyle;
                    break;
                case "JavaScript":
                    style = JavaScriptStyle;
                    break;
                case "C":
                    style = CStyle;
                    break;
                case "C#":
                    style = CsharpStyle;
                    break;
                case "Ruby":
                    style = RubyStyle;
                    break;
                default:
                    style = XSLTStyle;
                    break;
             
            }
            return style;
        }
    }
}
