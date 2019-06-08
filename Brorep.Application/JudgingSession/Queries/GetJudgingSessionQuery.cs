﻿using AutoMapper;
using Brorep.Application.JudgingSession.Models;
using Brorep.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Brorep.Application.JudgingSession.Queries
{
    public class GetJudgingSessionQuery : IRequest<JudgingSessionDto>
    {
        public Guid JudgingTypeId { get; }
        public GetJudgingSessionQuery(Guid judgingTypeId)
        {
            JudgingTypeId = judgingTypeId;
        }
    }

    public class GetJudgingSessionQueryHandler : IRequestHandler<GetJudgingSessionQuery, JudgingSessionDto>
    {
        private readonly BrorepDbContext _context;
        private readonly IMapper _mapper;

        public GetJudgingSessionQueryHandler(BrorepDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JudgingSessionDto> Handle(GetJudgingSessionQuery request, CancellationToken cancellationToken)
        {
            var judgingType = 
                await _context.JudgingTypes.FirstOrDefaultAsync(x => x.JudgingTypeId == request.JudgingTypeId, cancellationToken);

            switch(judgingType.Name)
            {
                case "10 Reps":
                    //do stuff
                    //_context.Submissions.
                break;
            }

            return new JudgingSessionDto();
        }
    }
}
