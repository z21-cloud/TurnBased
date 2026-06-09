using NUnit.Framework;
using TurnBased.Units;

public class SelectionManagerTests
{
    [Test] // Запускает метод как тест
    public void Select_WhenCalled_SavesCurrentSelection()
    {
        //1.  Подготовка
        // Создается реальный объект менеджера. Т.к. это чистый C#-класс, то можно создать через new
        var selectionManager = new SelectionManager();

        // Unit для теста, который реализует FakeSelectable
        var fakeSelectable = new FakeSelectable();

        // 2. Действие
        // вызывается метод, который надо протестировать
        selectionManager.Select(fakeSelectable);

        // 3. Проверка
        // Сравниваются 2 объекта и проверяются действительно ли они равны
        Assert.AreEqual(fakeSelectable, selectionManager.CurrentSelection(), "Expected manager to save selected object");
    }
}

public class FakeSelectable : ISelectable
{
    public void Select() {}
    public void Deselect() {}
}