using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace Unity.InteractiveTutorials
{
    enum ParagraphType
    {
        Narrative,
        Instruction,
        UnorderedList,
        OrderedList,
        Icons
    }

    [Serializable]
    class TutorialParagraph
    {
        public ParagraphType type { get { return m_Type; } }
        [SerializeField]
        internal ParagraphType m_Type;

        public string summary { get { return m_Summary; } set { m_Summary = value; } }
        [SerializeField, TextArea(1, 1)]
        string m_Summary = "";

        public string text { get { return m_Text; } set { m_Text = value; } }
        [SerializeField, TextArea(1, 5)]
        string m_Text = "";

        public IEnumerable<InlineIcon> icons
        {
            get
            {
                m_Icons.GetItems(m_IconBuffer);
                return m_IconBuffer;
            }
        }
        [SerializeField]
        InlineIconCollection m_Icons = new InlineIconCollection();
        readonly List<InlineIcon> m_IconBuffer = new List<InlineIcon>();

        [SerializeField] internal TypedCriterionCollection m_Criteria = new TypedCriterionCollection();
        readonly List<TypedCriterion> m_CriteriaBuffer = new List<TypedCriterion>();

        public IEnumerable<TypedCriterion> criteria
        {
            get
            {
                m_Criteria.GetItems(m_CriteriaBuffer);
                return m_CriteriaBuffer;
            }
        }

        public MaskingSettings maskingSettings { get { return m_MaskingSettings; } }
        [SerializeField]
        MaskingSettings m_MaskingSettings = new MaskingSettings();

        public bool completed
        {
            get
            {
                foreach (var typedCriterion in m_Criteria)
                {
                    var criterion = typedCriterion.criterion;
                    if (criterion != null)
                    {
                        if (!criterion.completed)
                            return false;
                    }
                }
                return true;
            }
        }
    }

    [Serializable]
    class TutorialParagraphCollection : CollectionWrapper<TutorialParagraph>
    {
        public TutorialParagraphCollection() : base()
        {
        }

        public TutorialParagraphCollection(IList<TutorialParagraph> items) : base(items)
        {
        }
    }
}
