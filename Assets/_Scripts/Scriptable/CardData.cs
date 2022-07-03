using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardGame/CardData", order = 0)]
public class CardData : ScriptableObject
{
    [SerializeField] private string title;
    [SerializeField] private string desc;
    [SerializeField] private Sprite sprite;

    public string Title{ get => title; }
    public string Desc{ get => desc; }
    public Sprite Sprite{ get => sprite; }
}
