using MMS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace System.Web.Mvc.Html
{
    public static class BootstrapHelper
    {
        public static MvcHtmlString FormLineDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes = null)
        {
            return (FormLineDropDownListFor(helper, expression, null, false, null, null, htmlAttributes));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="selectList"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString FormLineDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> selectList,
            object htmlAttributes = null)
        {
            return (FormLineDropDownListFor(helper, expression, selectList, false, null, null, htmlAttributes));
        }

        /// <summary>
        /// Overloaded version of FormLineDropDownListFor
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="selectList"></param>
        /// <param name="isBigLabel"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString FormLineDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> selectList,
            bool isBigLabel,
            object htmlAttributes = null)
        {
            return (FormLineDropDownListFor(helper, expression, selectList, isBigLabel, null, null, htmlAttributes)); 
        }

        /// <summary>
        /// Primary method version of FormLineDropDownListFor
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="selectList"></param>
        /// <param name="labelText"></param>
        /// <param name="isBigLabel"></param>
        /// <param name="customHelpText"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString FormLineDropDownListFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper, 
            Expression<Func<TModel, TProperty>> expression, 
            IEnumerable<SelectListItem> selectList,
            bool isBigLabel,
            string labelText, 
            string customHelpText = null, 
            object htmlAttributes = null)
        {
            object labelHtmlAttributes = "";

            if (isBigLabel)
                labelHtmlAttributes = new { @class = "control-label control-label-big" };

            string label = helper.LabelFor(expression, labelText, labelHtmlAttributes).ToString() + helper.HelpTextFor(expression, customHelpText);

            return FormLine(label,
                helper.DropDownListFor(expression, selectList, htmlAttributes).ToString() + helper.ValidationMessageFor(expression),
                isBigLabel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="templateName"></param>
        /// <param name="labelText"></param>
        /// <param name="isBigLabel"></param>
        /// <param name="customHelpText"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString FormLineEditorFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper, 
            Expression<Func<TModel, TProperty>> expression, 
            string templateName = null, 
            string labelText = null,
            bool isBigLabel = false,
            string customHelpText = null, 
            object htmlAttributes = null)
        {
            return FormLine(
                helper.LabelFor(expression, labelText, htmlAttributes).ToString() + helper.HelpTextFor(expression, customHelpText),
                helper.EditorFor(expression, templateName, htmlAttributes).ToString() + helper.ValidationMessageFor(expression),
                isBigLabel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="isBigLabel"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString FormLineTextBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression)
        {
            return (FormLineTextBoxFor(helper, expression, false, null, null, null, null));
        }

        public static MvcHtmlString FormLineTextBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes = null)
        {
            return (FormLineTextBoxFor(helper, expression, false, null, null, null, null));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="isBigLabel"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString FormLineTextBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            bool isBigLabel,
            object htmlAttributes = null)
        {
            return (FormLineTextBoxFor(helper, expression, isBigLabel, null, null, null, htmlAttributes));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="templateName"></param>
        /// <param name="labelText"></param>
        /// <param name="isBigLabel"></param>
        /// <param name="customHelpText"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString FormLineTextBoxFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> expression,
            bool isBigLabel,
            string templateName,
            string labelText,
            string customHelpText = null,
            object htmlAttributes = null)
        {
            object labelHtmlAttributes = "";

            if (isBigLabel)
                labelHtmlAttributes = new { @class = "control-label control-label-big" };

            string label = helper.LabelFor(expression, labelText, labelHtmlAttributes).ToString() + helper.HelpTextFor(expression, customHelpText);

            return FormLine(label, helper.TextBoxFor(expression, templateName, htmlAttributes).ToString() + helper.ValidationMessageFor(expression), isBigLabel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelContent"></param>
        /// <param name="fieldContent"></param>
        /// <param name="isBigLabel"></param>
        /// <param name="labelHtmlAttributes"></param>
        /// <param name="fieldHtmlAttributes"></param>
        /// <param name="containerHtmlAttributes"></param>
        /// <returns></returns>
        private static MvcHtmlString FormLine(
            string labelContent, 
            string fieldContent,
            bool isBigLabel,
            object labelHtmlAttributes = null,
            object fieldHtmlAttributes = null,
            object containerHtmlAttributes = null)
        {
            // The label
            //var editorLabel = new TagBuilder("label");
            //editorLabel.InnerHtml = labelContent;

            //if (isBigLabel)
            //    editorLabel.AddCssClass("");
            //else
            //    editorLabel.AddCssClass("control-label");

            //// Additional HTML attributes
            //if (labelHtmlAttributes != null)
            //    editorLabel.MergeAttributes(new RouteValueDictionary(labelHtmlAttributes));

            // The field
            var editorField = new TagBuilder("div");
            editorField.AddCssClass("controls");
            editorField.InnerHtml += fieldContent;
            
            // Additional HTML attributes
            if (fieldHtmlAttributes != null)
                editorField.MergeAttributes(new RouteValueDictionary(fieldHtmlAttributes));

            // The container div
            var container = new TagBuilder("div");
            container.AddCssClass("control-group");
            container.InnerHtml += labelContent;
            container.InnerHtml += editorField;

            // Additional HTML attributes
            if (containerHtmlAttributes != null)
                container.MergeAttributes(new RouteValueDictionary(containerHtmlAttributes));
            
            return MvcHtmlString.Create(container.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <param name="customText"></param>
        /// <returns></returns>
        public static MvcHtmlString HelpTextFor<TModel, TProperty>(
            this HtmlHelper<TModel> helper, 
            Expression<Func<TModel, TProperty>> expression, 
            string customText = null)
        {
            // Can do all sorts of things here -- eg: reflect over attributes and add hints, etc...
            return MvcHtmlString.Create("");
        }    
    }
}