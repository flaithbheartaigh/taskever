using Abp.Configuration;
using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Shouldly;

using Taskever.Test;

namespace Taskever.Tests.Settings
{
    [Trait("Exploratory", "Setting Definition Load From database")]
    public class TaskeverEmailSettingsDefinition_Tests: TaskeverTestBase
    {
        ISettingManager SettingManager;
        public TaskeverEmailSettingsDefinition_Tests():base()
        {
            SettingManager = Resolve<ISettingManager>();
        }

        [Fact]
        public void stest()
        {            
            SettingManager.GetSettingValue("Abp.Net.Mail.SenderAddress").ShouldBe("alanflaherty@mail.com");
        }
    }
}
