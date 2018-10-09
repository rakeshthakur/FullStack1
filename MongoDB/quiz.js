db.popluation.find({})

db.poplulation.aggregate([
    {
        $group:{_id:"$region", totalState:{$sum:1}, state:{$push:"$name"}},
    },
    {
        $unwind: "$state"
    }
    ]);
    
db.poplulation.aggregate([
    {
        $group:{_id: null, totalArea:{$sum:"$area"}}
    },
    {
        $project: {name:"$_id", _id:0, totalArea:1}
    }
])

db.poplulation.aggregate([
    {
        $unwind: "$population"
    },
    {
        $sort: {"population.year":1}
    },
    {
        $group:{
            "_id":"$name",
            "pop1991": {$first: "$population.population"},
            "pop2011": {$last: "$population.population"}
        }
    },
    {
        $project: {
            "_id":0,
            "state":"$_id",
            "1991":"$pop1991",
            "2011":"$pop2011",
            "Variance":{$subtract: ["$pop2011","$pop1991"]}
        }
    },
    {$sort: {"state":1}}
])
