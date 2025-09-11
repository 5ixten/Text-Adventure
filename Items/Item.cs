using System;

namespace TextAdventure;

public interface Item
{
	public string Name { get; set; }
	public ItemType ItemType { get; set; }
	public void Use(Character character);
}
