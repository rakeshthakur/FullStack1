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

db.products.find({}).limit(5).count()





