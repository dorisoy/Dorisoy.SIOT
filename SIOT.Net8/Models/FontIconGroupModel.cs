using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOT.Models;

public class FontIconGroupModel : List<FontIconModel>
{
    public string GroupName { get; set; }
    public List<FontIconModel> IconList { get; set; }
    public FontIconGroupModel(string groupName, List<FontIconModel> iconList) : base(iconList)
    {
        GroupName = groupName;
        IconList = iconList;
    }

    public override string ToString()
    {
        return GroupName;
    }
}

public class FontIconModel
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
