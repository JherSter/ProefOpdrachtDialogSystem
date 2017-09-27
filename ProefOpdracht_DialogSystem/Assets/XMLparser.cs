using UnityEngine;

using System.Collections;

using System.Collections.Generic;

using System.Xml; 

using System.Xml.Serialization;

using System.IO;

using System.Xml.Linq;



public class XMLparser : MonoBehaviour
{
	public string NameOfNpc, Dialog, Answers, Farwell;
	public int Interation = 0, PageNume = 0;
	private XDocument _xmlDoc;
	private IEnumerable<XElement> _items;


	private readonly List <XmlData> _data = new List <XmlData>();
	
		

	// Use this for initialization
	private void Start () {
		DontDestroyOnLoad(gameObject);
		LoadXml();
		StartCoroutine(Assign());
	}

	private void LoadXml()
	{
		_xmlDoc = XDocument.Load("Assets/conversation.xml");
		_items = _xmlDoc.Descendants("page").Elements();
	}
	private void Update(){
		StartCoroutine(Assign());
	}

	private IEnumerator Assign()
	{
		
		foreach (var item in _items)
		{
			if (item.Parent.Attribute("number").Value != Interation.ToString()) continue;
			PageNume = int.Parse(item.Parent.Attribute("number").Value);
			NameOfNpc = item.Parent.Element("name").Value.Trim ();
			Dialog = item.Parent.Element("dialogue").Value.Trim();
			Answers = item.Parent.Element("answers").Value.Trim();
			Farwell = item.Parent.Element("farwell").Value.Trim();
			_data.Add(new XmlData(PageNume, NameOfNpc, Dialog));

			
		}
		yield return null;
	}
	public class XmlData
	{
		public int PageNum;
		public string nameOfNPC;
		public string DialogueText;

		public XmlData(int page, string character, string dialog)
		{
			PageNum = page;
			nameOfNPC = character;
			DialogueText = dialog;
		}
	}
	
	
}

