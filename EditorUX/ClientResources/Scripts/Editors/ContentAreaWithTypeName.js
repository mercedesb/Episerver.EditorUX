define([
        "dojo/_base/array",
        "dojo/_base/connect",
        "dojo/_base/declare",
        "dojo/_base/lang",
        "dojo/query",
        "dojo/dom-class",
        "dojo/on",
        "dojo/dom",
        "epi/epi",
        "epi/dependency",
        "epi-cms/contentediting/editors/ContentAreaEditor"
],
    function (
        array,
        connect,
        declare,
        lang,
        query,
        domClass,
        on,
        dom,
        epi,
        dependency,
        _ContentAreaEditor
    ) {
    	return declare("makingwaves.editors.ContentAreaWithTypeName", [_ContentAreaEditor], {
    		buildRendering: function () {
    			this.inherited(arguments);

    			var self = this;

    			// override _createTreeNode method
    			var _createTreeNode = this.tree._createTreeNode;
    			this.tree._createTreeNode = lang.hitch(this.tree, function (model) {
    				var node = _createTreeNode.call(this, model);
    				self._modifyNode.call(self, node, model);
    				return node;
    			});
    		},

    		_modifyNode: function (node, model) {
    			var spanLabel = query("span.dijitTreeLabel", node.domNode);
    			if (spanLabel == null || spanLabel.length == 0) {
    				return;
    			}

    			this._resolveContentData(model.item.contentLink, lang.hitch(this, function (content) {

    				// setup span
    				spanLabel = spanLabel[0];
    				console.log(content.contentTypeName);
    				spanLabel.innerHTML = spanLabel.innerHTML + " <em>(" + content.contentTypeName + ")</em>";
    			}));
    		},

    		_resolveContentData: function (contentlink, callback) {
    			var registry = dependency.resolve("epi.storeregistry");
    			var store = registry.get("epi.cms.content.light");
    			if (!contentlink) {
    				return null;
    			}

    			var contentData;
    			dojo.when(store.get(contentlink), function (returnValue) {
    				contentData = returnValue;
    				callback(contentData);
    			});
    			return contentData;
    		},
    	});
    });