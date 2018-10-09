db.products.find({availability:"Available"})

db.products.find({}, {
    _id:0,
    pname:1,
    price:1
})


db.products.find({}, {
    _id:0,
    category:0
})

db.products.find({}).count()

db.products.find({}).skip(5).limit(3)

db.products.find({}).sort({ pid:-1 }).limit(5)
.count()

db.products.find({"price":{ $gt:20}})

db.products.find({
    $and:[
        {"category.cname":"Fruits"},
        {"pname":"Apple"}
        ]
})




db.students.find({"marks": {$all: [42,43,25]}})

db.students.find({},{"marks": {$slice: [0,3]}})

db.students.aggregate([
      { $group: { _id: "$location", totalStudent:{$count: "1"}}: { allUsers: true, idleConnections: true } },
      //{ $match: { shard: "shard01" } }
])

db.students.aggregate([
    {$group: { _id: "$location", totalStudents: {$sum:1 }}}
    ])

db.students.aggregate([
    {
        $match: {"location":"Chennai"}
    },
    {
        $unwind: "$marks"
    },
    {
        $group: { 
            _id: "$_id",
            name: "$name", 
            totalMarks: {$sum:"$marks" }
        }
    }/*,
    {
        $project: {name:"$_id", _id:0, totalMarks:1}   
    }*/
    ])
    