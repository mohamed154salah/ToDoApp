using ToDoApp.Utils;
namespace ToDoApp.Test
{
    public class UnitTestUtilites
    {
        [Fact]
        public void Add_Task()
        {
            // Arrange
            Utilities util = new Utilities();
            // Act
            bool result = util.AddTask("test", "test", Priority.High);
            // Assert
            Assert.True(result);

        }

        [Fact]
        public void Add_Task_With_Same_Name()
        {
            // Arrange
            Utilities util = new Utilities();
            util.AddTask("test", "test", Priority.High);
            // Act
            bool result = util.AddTask("test", "test", Priority.High);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Delete_Task_Not_Exist()
        {
            // Arrange
            Utilities util = new Utilities();
            // Act
            bool result = util.CompleteTask("test");
            // Assert
            Assert.False(result);
        }


        [Fact]
        public void Delete_Task()
        {
            // Arrange
            Utilities util = new Utilities();
            util.AddTask("test", "test", Priority.High);
            // Act
            bool result = util.CompleteTask("test");
            // Assert
            Assert.True( result);
        }

        [Fact]
        public void List_All_Tasks()
        {
            // Arrange
            Utilities util = new Utilities();
            util.AddTask("test", "test", Priority.High);
            util.AddTask("test2", "test2", Priority.Low);
            int count = 2;
            // Act
            List<KeyValuePair<string, Task>> result = util.ListAllTasks();
            // Assert
            Assert.Equal(count, result.Count);
        }
        [Fact]
        public void List_All_Tasks_With_Right_Arrange_Priority()
        {
            // Arrange

            Utilities util = new Utilities();
            util.AddTask("test", "test", Priority.High);
            util.AddTask("test2", "test2", Priority.Medium);
            util.AddTask("test3", "test3", Priority.Low);
            int[]priorities=new int[3] {0,1,2};

            // Act

            List<KeyValuePair<string,Task>> list = util.ListAllTasks();
            int[] resultPriorities = new int[3];
            int count = 0;
            foreach (KeyValuePair<string, ToDoApp.Task> task in list)
            {
                resultPriorities[count] = (int)task.Value.Priority;
                count++;
            }

            // Assert

            Assert.Equal(priorities, resultPriorities);
        }

        [Fact]
        public void Edit_Task()
        {
            // Arrange

            Utilities util = new Utilities();
            util.AddTask("test", "test", Priority.High);

            // Act

            bool result = util.EditTask("test",null, "test is test", Priority.Low);

            // Assert

            Assert.True(result);
        }

        [Fact]
        public void Edit_Task_Not_Exist()
        {
            // Arrange
            Utilities util = new Utilities();
            // Act
            bool result = util.EditTask("test", "test", "test is test", Priority.Low);
            // Assert
            Assert.False(result);
        }
      
    }
}