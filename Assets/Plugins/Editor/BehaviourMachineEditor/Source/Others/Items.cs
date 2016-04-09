//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Base class for items (scripts and namespaces) that are arranged in a tree hierarchy struct.
    /// Used by the AddNodeWindow to draw the node scripts.
    /// <seealso cref="BehaviourMachineEditor.AddNodeWindow" />
    /// </summary>
    public abstract class Item {

        #region Members
        /// <summary>
        /// The item name.
        /// </summary>
        public readonly string name;

        /// <summary>
        /// The item parent.
        /// </summary>
        public readonly Category parent;
        #endregion Members

        
        #region Properties
        /// <summary>
        /// The ancestor hierarchy of the item.
        /// </summary>
        public string path {get {return (parent != null && parent.parent != null ? parent.path + "/" : string.Empty) + name;}}
        #endregion Properties

        /// <summary>
        /// Item constructor.
        /// <param name="parent">The parent of this item.</param>
        /// <param name="name">The time name.</param>
        /// </summary>
        public Item (Category parent, string name) {
            this.parent = parent;
            this.name = name;
        }

        /// <summary>
        /// The derived classes should implement this method to return the item icon.
        /// </summary>
        public abstract Texture GetIcon ();
    }

    /// <summary>
    /// Parent class for Items.
    /// </summary>
    public class Category : Item {

        #region Members
        Texture m_Icon = null;
        List<Item> m_Children = new List<Item>();
        #endregion Members

        
        #region Properties
        /// <summary>
        /// Returns the children in this category.
        /// </summary>
        public Item[] children {private set {} get {return m_Children.ToArray();}}
        #endregion Properties

       
        /// <summary>
        /// The Category constructor.
        /// <param name="parent">The parent of this category.</param>
        /// <param name="name">The category name.</param>
        /// </summary>
        public Category (Category parent, string name) : base (parent, name) {}

        
        #region Public Methods
        /// <summary>
        /// Returns the Category icon.
        /// <returns>The icon of this category.</returns>
        /// </summary>
        public override Texture GetIcon () {
            if (m_Icon == null)
                m_Icon = EditorGUIUtility.FindTexture("Folder Icon");
            return m_Icon;
        }

        /// <summary>
        /// Returns a child item that has the supplied name.
        /// <param name="childName">The child name to search for.</param>
        /// <returns>The child item that has the same name as the parameter childName.</returns>
        /// </summary>
        Item GetChild (string childName) {
            return m_Children.FirstOrDefault(x => x.name == childName);
        }

        /// <summary>
        /// Adds a new child in this category.
        /// If category is not null creates a new category child; otherwise creates a new Script child.
        /// <param name="category">The name of the category.</param>
        /// <param name="type">The type of the node.</param>
        /// <param name="NodeInfo">The node info of the script.</param>
        /// </summary>
        public void AddChild (string category, System.Type type, NodeInfoAttribute NodeInfo) {
            if (category == null)
                category = string.Empty;

            string[] splitedCategory = category.Split('/');

            // The category is not null or empty?
            if (splitedCategory.Length > 0 && splitedCategory[0] != string.Empty) {
                var desiredCategoryChild = GetChild(splitedCategory[0]) as Category;

                // The Category does not exist?
                if (desiredCategoryChild == null) {
                    // Create a new category
                    desiredCategoryChild = new Category(this, splitedCategory[0]);
                    m_Children.Add(desiredCategoryChild);
                }

                // Continues searching in the children category
                string removeSubString =  category.Contains(splitedCategory[0] + "/") ? splitedCategory[0] + "/" : splitedCategory[0];
                int index = category.IndexOf(removeSubString);
                desiredCategoryChild.AddChild(category.Remove(index, removeSubString.Length), type, NodeInfo);
            }
            else {
                Item desiredChild = GetChild(type.ToString());
                // The Script does not exist?
                if (desiredChild == null)
                    m_Children.Add(new Script(this, type.Name, type, NodeInfo));
            }
        }
        #endregion Public Methods
    }


    /// <summary>
    /// An Item that stores a node script.
    /// </summary>
    public class Script : Item {
        public enum NodeType {Action, Condition, Composite, Decorator, MissingNode}

        #region Members
        Texture m_Icon;

        /// <summary>
        /// The node type that is stored by this item.
        /// </summary>
        public readonly System.Type type;

        /// <summary>
        /// The script meta information.
        /// </summary>
        public readonly NodeInfoAttribute nodeInfo;

        public readonly NodeType nodeType;
        #endregion Members

        #region Properties
        /// <summary>
        /// Returns the node type description.
        /// </summary>
        public string description {get {return nodeInfo.description;}}
        #endregion Properties

        /// <summary>
        /// Constructor for a Script object.
        /// <param name="parent">The parent category of this item.</param>
        /// <param name="name">The name of the item.</param>
        /// <param name="type">The MonoScript that will be stored in this item.</param>
        /// <param name="nodeInfo">Meta information about the node type in the type.</param>
        /// </summary>
        public Script (Category parent, string name, System.Type type, NodeInfoAttribute nodeInfo) : base (parent, name) {
            this.type = type;
            this.nodeInfo = nodeInfo;

            if (type.IsSubclassOf(typeof(ConditionNode)))
                nodeType = NodeType.Condition;
            else if (type.IsSubclassOf(typeof(DecoratorNode)))
                nodeType = NodeType.Decorator;
            else if (type == typeof(MissingNode))
                nodeType = NodeType.MissingNode;
            else if (type.IsSubclassOf(typeof(CompositeNode)))
                nodeType = NodeType.Composite;
            else
                nodeType = NodeType.Action;
        }

        #region Public Methods
        /// <summary>
        /// Returns the node type icon.
        /// <returns>The node icon.</returns>
        /// </summary>
        public override Texture GetIcon () {
            if (m_Icon == null)
                m_Icon = IconUtility.GetIcon(this.type);
            return m_Icon;
        }
        #endregion Public Methods
    }
}