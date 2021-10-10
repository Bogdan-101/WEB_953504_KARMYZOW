public class Game
{
    public int Id { get; set; } // id игры
    public string Name { get; set; } // название игры
    public string Description { get; set; } // описание игры
    public int Rating { get; set; } // оценка пользователей
    public string Image { get; set; } // имя файла изображения
    // Навигационные свойства
    /// <summary>
    /// группа блюд (например, супы, напитки и т.д.)
    /// </summary>
    public int GameGroupId { get; set; }
    public GameGroup Group { get; set; }
}
