using DPAT_eindopdracht.Domain.Cell;
using DPAT_eindopdracht.Domain.Group;
using DPAT_eindopdracht.Domain.Validation;
using Xunit;
using System;
using System.Collections.Generic;
using NSubstitute;

namespace DPAT_eindopdracht.test.Domain;

public class GroupTest
{
    [Fact]
    public void CanCreateGroupWithoutValidators()
    {
        var factory = new GroupFactory();
        factory.AddGroupType(typeof(Group), Group.GroupTypes.Unique);

        var group = factory.CreateGroup(Group.GroupTypes.Unique, new List<Cell>(), "test");

        Assert.Empty(group!.Validators);
    }
    
    [Fact]
    public void CanCreatePresetGroupWithValidation()
    {
        var factory = SetFactory();
        
        var group = CreateTestGroup(factory);
        
        Assert.NotEmpty(group.Validators);
    }
    
    [Fact]
    public void GroupAlwaysHasCells()
    {
        var factory = SetFactory();
        
        var group = CreateTestGroup(factory);
        
        Assert.NotNull(group.Cells);
    }
    
    [Fact]
    public void GroupTypeIsSet()
    {
        var factory = SetFactory();
        
        var group = CreateTestGroup(factory);
        
        Assert.NotNull(group.Type);
    }
    
    [Fact]
    public void GroupCanValidate()
    {
        var factory = SetFactory();

        var group = CreateTestGroup(factory);
        var validationResult = group.Validate();
        
        
        Assert.NotNull(group);
        Assert.IsType<bool>(validationResult);
    }
    
    [Fact]
    public void CannotUseInterfaceAsValidator()
    {
        var factory = new GroupFactory();
        factory.AddGroupType(typeof(IValidator), Group.GroupTypes.Unique);
        
        
        Assert.Throws<MissingMethodException>(() => 
            factory.CreateGroup(Group.GroupTypes.Unique, new List<Cell>(), "test")
            );
    }
    
    [Fact]
    public void CanAddGenericValidator()
    {
        var factory = SetFactory();

        var group = CreateTestGroup(factory);
        var validator = Substitute.For<IValidator>();
        group.AddValidator(validator);
        
        Assert.NotNull(group);
        Assert.Equal(2, group.Validators.Count);
    }

    private GroupFactory SetFactory()
    {
        var factory = new GroupFactory();
        factory.AddGroupType(typeof(UniqueGroup), Group.GroupTypes.Unique);
        return factory;
    }

    private Group CreateTestGroup(GroupFactory factory)
    {
        return factory.CreateGroup(
            Group.GroupTypes.Unique, new List<Cell>(), "test") ?? new Group(new List<Cell>()
        );
    }
}