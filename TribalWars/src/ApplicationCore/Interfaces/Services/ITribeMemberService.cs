using ApplicationCore.Results;
using System;
﻿using ApplicationCore.Entities;
using ApplicationCore.Results.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ITribeMemberService
    {
        Task<ServiceResult> InviteNewMember(Guid playerId, Guid invitedPlayerId);

        Task<ServiceResult> GetTribeUsersByTribeId(int tribeId);
    }
}
