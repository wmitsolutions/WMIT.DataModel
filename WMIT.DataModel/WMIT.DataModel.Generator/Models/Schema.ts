interface Property {
    name: string
    type: string
}
interface Model {
    name: string
    properties: Property[]
}
interface Schema {
    models: Model[]
}

var schema: Schema = {
    models: [
        {
            name: 'Person',
            properties: [
                { name: 'Id', type: 'number', attributes: [] },
                { name: 'Firstname', type: 'string' },
                { name: 'Lastname', type: 'string' }
            ]
        }
    ]
}

class PersonBase {
    public Id: number
    public Firstname: string
    public Lastname: string

    public CreatedAt: Date
}