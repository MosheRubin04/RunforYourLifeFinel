using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementStats
{
    float MaxSpeed { get; }
    float MinSpeed { get;  }
    float ExcelarationRate { get;  }

    float ForwerdSpeed { get;  }
    float TurnSpeed { get;  }
    float Distance { get;  }
    float SlideDuration { get;  }
    float JumpStrength { get;  }
    float JumpDuration { get;  }


}

