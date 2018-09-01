//
// TestToolboxProvider.cs
//
// Author:
//       Matt Ward <matt.ward@microsoft.com>
//
// Copyright (c) 2018 Microsoft
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using MonoDevelop.DesignerSupport.Toolbox;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Content;

namespace ToolboxTestAddin
{
	public class TestToolboxProvider : IToolboxDynamicProvider
	{
		public event EventHandler ItemsChanged;

		public IEnumerable<ItemToolboxNode> GetDynamicItems (IToolboxConsumer consumer)
		{
			var content = consumer as ViewContent;
			if (content == null || !content.IsFile)
				yield break;

			if (!(content is ITextEditorResolver))
				yield break;

			yield return new TextToolboxNode ("Test 1") {
				Category = "Test Toolbox Category",
				Name = "Test 1",
				Icon = ImageService.GetIcon ("md-template", Gtk.IconSize.Menu)
			};
		}
	}
}
