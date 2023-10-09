﻿namespace InteractiveAutomationToolkitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Net.AutomationUI.Objects;
    using Skyline.DataMiner.Utils.InteractiveAutomationScript;
    using Skyline.DataMiner.Utils.InteractiveAutomationScript.Components;

    [TestClass]
    public class ComponentTests
    {
        /// <summary>
        /// Checks if the WantsOnChange property of a Button is correctly updated when the Pressed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeButtonOnPressedEvent()
        {
            Button button = new Button("Button 1");
            Assert.IsFalse(button.BlockDefinition.WantsOnChange);

            button.Pressed += Button_Pressed;
            Assert.IsTrue(button.BlockDefinition.WantsOnChange);

            button.Pressed -= Button_Pressed;
            Assert.IsFalse(button.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a CheckBox is correctly updated when the Changed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeCheckBoxOnChangedEvent()
        {
            CheckBox checkBox = new CheckBox();
            Assert.IsFalse(checkBox.BlockDefinition.WantsOnChange);

            checkBox.Changed += CheckBox_Changed;
            Assert.IsTrue(checkBox.BlockDefinition.WantsOnChange);

            checkBox.Changed -= CheckBox_Changed;
            Assert.IsFalse(checkBox.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a CheckBox is correctly updated when the Checked event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeCheckBoxOnCheckedEvent()
        {
            CheckBox checkBox = new CheckBox();
            Assert.IsFalse(checkBox.BlockDefinition.WantsOnChange);

            checkBox.Checked += CheckBox_Checked;
            Assert.IsTrue(checkBox.BlockDefinition.WantsOnChange);

            checkBox.Checked -= CheckBox_Checked;
            Assert.IsFalse(checkBox.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a CheckBox is correctly updated when the UnChecked event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeCheckBoxOnUnCheckedEvent()
        {
            CheckBox checkBox = new CheckBox();
            Assert.IsFalse(checkBox.BlockDefinition.WantsOnChange);

            checkBox.UnChecked += CheckBox_UnChecked;
            Assert.IsTrue(checkBox.BlockDefinition.WantsOnChange);

            checkBox.UnChecked -= CheckBox_UnChecked;
            Assert.IsFalse(checkBox.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a CheckBoxList is correctly updated when the UnChecked event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeCheckBoxListOnChangedEvent()
        {
            string[] options = new string[] { "Option1", "Option2", "Option3" };
            CheckBoxList checkBoxList = new CheckBoxList(options);
            Assert.IsFalse(checkBoxList.BlockDefinition.WantsOnChange);

            checkBoxList.Changed += CheckBoxList_Changed;
            Assert.IsTrue(checkBoxList.BlockDefinition.WantsOnChange);

            checkBoxList.Changed -= CheckBoxList_Changed;
            Assert.IsFalse(checkBoxList.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a CollapseButton is correctly updated when the Pressed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeCollapseButtonOnPressedEvent()
        {
            IEnumerable<Widget> widgets = new Widget[] { new Label("Label1"), new Label("Label2") };
            CollapseButton collapseButton = new CollapseButton(widgets, false);
            Assert.IsTrue(collapseButton.BlockDefinition.WantsOnChange);

            collapseButton.Pressed += CollapseButton_Pressed;
            Assert.IsTrue(collapseButton.BlockDefinition.WantsOnChange);

            collapseButton.Pressed -= CollapseButton_Pressed;
            Assert.IsTrue(collapseButton.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a Calendar is correctly updated when the Changed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeCalendarOnChangedEvent()
        {
            Calendar calendar = new Calendar();
            Assert.IsFalse(calendar.BlockDefinition.WantsOnChange);

            calendar.Changed += Calendar_Changed;
            Assert.IsTrue(calendar.BlockDefinition.WantsOnChange);

            calendar.Changed -= Calendar_Changed;
            Assert.IsFalse(calendar.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a DateTimePicker is correctly updated when the Changed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeDateTimePickerOnChangedEvent()
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            Assert.IsFalse(dateTimePicker.BlockDefinition.WantsOnChange);

            dateTimePicker.Changed += DateTimePicker_Changed;
            Assert.IsTrue(dateTimePicker.BlockDefinition.WantsOnChange);

            dateTimePicker.Changed -= DateTimePicker_Changed;
            Assert.IsFalse(dateTimePicker.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a DropDown is correctly updated when the Changed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeDropDownOnChangedEvent()
        {
            string[] options = new string[] { "Option1", "Option2", "Option3" };
            DropDown dropDown = new DropDown(options);
            Assert.IsFalse(dropDown.BlockDefinition.WantsOnChange);

            dropDown.Changed += DropDown_Changed;
            Assert.IsTrue(dropDown.BlockDefinition.WantsOnChange);

            dropDown.Changed -= DropDown_Changed;
            Assert.IsFalse(dropDown.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a Numeric is correctly updated when the Changed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeNumericOnChangedEvent()
        {
            Numeric numeric = new Numeric();
            Assert.IsFalse(numeric.BlockDefinition.WantsOnChange);

            numeric.Changed += Numeric_Changed;
            Assert.IsTrue(numeric.BlockDefinition.WantsOnChange);

            numeric.Changed -= Numeric_Changed;
            Assert.IsFalse(numeric.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a RadioButtonList is correctly updated when the Changed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeRadioButtonListOnChangedEvent()
        {
            string[] options = new string[] { "Option1", "Option2", "Option3" };
            RadioButtonList radioButtonList = new RadioButtonList(options);
            Assert.IsFalse(radioButtonList.BlockDefinition.WantsOnChange);

            radioButtonList.Changed += RadioButtonList_Changed;
            Assert.IsTrue(radioButtonList.BlockDefinition.WantsOnChange);

            radioButtonList.Changed -= RadioButtonList_Changed;
            Assert.IsFalse(radioButtonList.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a TextBox is correctly updated when the Changed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeTextBoxOnChangedEvent()
        {
            TextBox textBox = new TextBox();
            Assert.IsFalse(textBox.BlockDefinition.WantsOnChange);

            textBox.Changed += TextBox_Changed;
            Assert.IsTrue(textBox.BlockDefinition.WantsOnChange);

            textBox.Changed -= TextBox_Changed;
            Assert.IsFalse(textBox.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the WantsOnChange property of a TimePicker is correctly updated when the Changed event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void WantsOnChangeTimePickerOnChangedEvent()
        {
            TimePicker timePicker = new TimePicker();
            Assert.IsFalse(timePicker.BlockDefinition.WantsOnChange);

            timePicker.Changed += TimePicker_Changed;
            Assert.IsTrue(timePicker.BlockDefinition.WantsOnChange);

            timePicker.Changed -= TimePicker_Changed;
            Assert.IsFalse(timePicker.BlockDefinition.WantsOnChange);
        }

        /// <summary>
        /// Checks if the ReturnWhenDownloadIsStarted property of a DownloadButton is correctly updated when the ReturnWhenDownloadIsStarted event is subscribed and unsubcribed to.
        /// </summary>
        [TestMethod]
        public void ReturnOnDownloadIsStartedOnDownloadStartedEvent()
        {
            DownloadButton downloadButton = new DownloadButton();
            var configOptions = downloadButton.BlockDefinition.ConfigOptions as AutomationDownloadButtonOptions;
            Assert.IsFalse(configOptions.ReturnWhenDownloadIsStarted);

            downloadButton.DownloadStarted += DownloadButton_DownloadStarted;
            Assert.IsTrue(configOptions.ReturnWhenDownloadIsStarted);

            downloadButton.DownloadStarted -= DownloadButton_DownloadStarted;
            Assert.IsFalse(configOptions.ReturnWhenDownloadIsStarted);
        }

        /// <summary>
        /// Checks if the methods to manipulate the list of options on a dropdown are working as expected.
        /// </summary>
        [TestMethod]
        public void DropdownSetOptionsSelected()
        {
            string[] options = new string[] { "option1", "option2", "option3" };

            DropDown dropDown1 = new DropDown(options);
            Assert.AreEqual("option1", dropDown1.Selected);

            DropDown dropDown2 = new DropDown();
            dropDown2.SetOptions(options);
            Assert.AreEqual("option1", dropDown2.Selected);

            dropDown1.RemoveOption("option1");
            Assert.AreNotEqual("option1", dropDown1.Selected);

            dropDown1.SetOptions(options);
            Assert.AreEqual("option2", dropDown1.Selected);
        }

        [TestMethod]
        public void TestWidgetMargins()
        {
            Button button = new Button("Button");
            Assert.AreEqual(0, button.Margin.Left);

            button.Margin = new Margin(10, 5, 2, 1);
            Assert.AreEqual(2, button.Margin.Right);
        }

        [TestMethod]
        public void TestSection()
        {
            TestSection section = new TestSection();
            section.AddWidget(new Label("Label 1"), 0, 0);
            section.AddWidget(new Label("Label 2"), 1, 0);

            Assert.AreEqual(2, section.RowCount);
            Assert.AreEqual(1, section.ColumnCount);

            section.AddWidget(new Label("Label 3"), 3, 1);

            Assert.AreEqual(4, section.RowCount);
            Assert.AreEqual(2, section.ColumnCount);

            Assert.AreEqual(3, section.Widgets.Count());

            section.Clear();

            Assert.AreEqual(0, section.Widgets.Count());
        }

        [TestMethod]
        public void RemoveWidgetsFromSection()
        {
            TestSection section = new TestSection();
            Label label1 = new Label("Label 1");
            Label label2 = new Label("Label 2");

            section.AddWidget(label1, 0, 0);
            section.AddWidget(label2, 1, 0);

            Assert.AreEqual(2, section.Widgets.Count());
            Assert.AreEqual(2, section.RowCount);
            Assert.AreEqual(1, section.ColumnCount);

            section.RemoveWidget(label2);
            Assert.AreEqual(1, section.Widgets.Count());
            Assert.AreEqual(1, section.RowCount);
            Assert.AreEqual(1, section.ColumnCount);

            section.RemoveWidget(label1);
            Assert.AreEqual(0, section.Widgets.Count());
            Assert.AreEqual(0, section.RowCount);
            Assert.AreEqual(0, section.ColumnCount);
        }

        [TestMethod]
        public void RecreateUiBlockTest()
        {
            Exception exception = null;
            try
            {
                string[] options = new string[] { "option 1", "option 2", "option 3" };
                DropDown dropDown = new DropDown();
                dropDown.RemoveOption(options.First());

                dropDown.SetOptions(new string[] { "option 4", "option 5", "option 6" });
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.IsNull(exception);
        }

        [TestMethod]
        public void FindTreeViewItem()
        {
            TreeView treeView = new TreeView(new[] {
                new TreeViewItem("thomas", "thomasKey", new List<TreeViewItem>(new [] {
                    new TreeViewItem("thomasItem1", "thomasItem1Key", new List<TreeViewItem>(new [] {
                        new TreeViewItem("thomasItem11", "thomasItem11Key"),
                        new TreeViewItem("thomasItem12", "thomasItem12Key") }
                    )) })),
                new TreeViewItem("brian", "brianKey", new List<TreeViewItem>(new [] {
                    new TreeViewItem("brianItem1", "brianItem1Key")}))});

            TreeViewItem brianItem1;
            bool brianItem1Found = treeView.TryFindTreeViewItem("brianItem1Key", out brianItem1);
            Assert.IsNotNull(brianItem1);
            Assert.IsTrue(brianItem1Found);

            TreeViewItem thomasItem12;
            bool thomasItem12Found = treeView.TryFindTreeViewItem("thomasItem12Key", out thomasItem12);
            Assert.IsNotNull(thomasItem12);
            Assert.IsTrue(thomasItem12Found);

            TreeViewItem thomasItem1;
            bool thomasItem1Found = treeView.TryFindTreeViewItem("thomasItem1Key", out thomasItem1);
            Assert.IsNotNull(thomasItem1);
            Assert.IsTrue(thomasItem1Found);

            TreeViewItem thomasItem;
            bool thomasItemFound = treeView.TryFindTreeViewItem("thomasKey", out thomasItem);
            Assert.IsNotNull(thomasItem);
            Assert.IsTrue(thomasItemFound);

            TreeViewItem randomItem;
            bool randomItemFound = treeView.TryFindTreeViewItem("randomItemKey", out randomItem);
            Assert.IsNull(randomItem);
            Assert.IsFalse(randomItemFound);
        }

        [TestMethod]
        public void FindTreeViewItemDepth()
        {
            TreeView treeView = new TreeView(new[] {
                new TreeViewItem("thomas", "thomasKey", new List<TreeViewItem>(new [] {
                    new TreeViewItem("thomasItem1", "thomasItem1Key", new List<TreeViewItem>(new [] {
                        new TreeViewItem("thomasItem11", "thomasItem11Key"),
                        new TreeViewItem("thomasItem12", "thomasItem12Key") }
                    )) })),
                new TreeViewItem("brian", "brianKey", new List<TreeViewItem>(new [] {
                    new TreeViewItem("brianItem1", "brianItem1Key")}))});

            List<TreeViewItem> itemsOnDepth0 = new List<TreeViewItem>(treeView.GetItems(0));
            Assert.AreEqual(2, itemsOnDepth0.Count);

            List<TreeViewItem> itemsOnDepth1 = new List<TreeViewItem>(treeView.GetItems(1));
            Assert.AreEqual(2, itemsOnDepth1.Count);

            List<TreeViewItem> itemsOnDepth2 = new List<TreeViewItem>(treeView.GetItems(2));
            Assert.AreEqual(2, itemsOnDepth2.Count);

            List<TreeViewItem> itemsOnDepth3 = new List<TreeViewItem>(treeView.GetItems(3));
            Assert.AreEqual(0, itemsOnDepth3.Count);
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            // do nothing
        }

        private void CheckBox_Changed(object sender, CheckBox.CheckBoxChangedEventArgs e)
        {
            // do nothing
        }

        private void CheckBox_Checked(object sender, EventArgs e)
        {
            // do nothing
        }

        private void CheckBox_UnChecked(object sender, EventArgs e)
        {
            // do nothing
        }

        private void CheckBoxList_Changed(object sender, CheckBoxList.CheckBoxListChangedEventArgs e)
        {
            // do nothing
        }

        private void CollapseButton_Pressed(object sender, EventArgs e)
        {
            // do nothing
        }

        private void Calendar_Changed(object sender, Calendar.CalendarChangedEventArgs e)
        {
            // do nothing
        }

        private void DateTimePicker_Changed(object sender, DateTimePicker.DateTimePickerChangedEventArgs e)
        {
            // do nothing
        }

        private void DropDown_Changed(object sender, DropDown.DropDownChangedEventArgs e)
        {
            // do nothing
        }

        private void Numeric_Changed(object sender, Numeric.NumericChangedEventArgs e)
        {
            // do nothing
        }

        private void RadioButtonList_Changed(object sender, RadioButtonList.RadioButtonChangedEventArgs e)
        {
            // do nothing
        }

        private void TextBox_Changed(object sender, TextBox.TextBoxChangedEventArgs e)
        {
            // do nothing
        }

        private void TimePicker_Changed(object sender, TimePicker.TimePickerChangedEventArgs e)
        {
            // do nothing
        }

        private void DownloadButton_DownloadStarted(object sender, EventArgs e)
        {
            // do nothing
        }
    }

    public class TestSection : Section
    {
    }
}
