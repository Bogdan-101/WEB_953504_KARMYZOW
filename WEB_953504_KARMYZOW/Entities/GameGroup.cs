using System.Collections.Generic;

public class GameGroup
{
    public int GameGroupId { get; set; }
    public string GroupName { get; set; }
    /// <summary>
    /// Навигационное свойство 1-ко-многим
    /// </summary>
    public List<Game> Games { get; set; }
}
