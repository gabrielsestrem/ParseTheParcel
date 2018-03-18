# Parse the parcel #

A simple console application to calculate the cost of shipping parcels.

Shipping costs are based on size with different prices for small, medium, and large boxes. Parcels exceeding the largest size or the weight limit of 25kg cannot be shipped.

When run, the application will return the cost to ship the parcel, or, if it cannot be shipped, a message indicating as such.

| Package Type | Length | Breadth | Height | Cost |
| --- | --- | --- | --- | --- | --- |
| Small | 200mm | 300mm | 150mm | $5.00 |
| Medium | 300mm | 400mm | 200mm| $7.50 |
| Large | 400mm | 600mm | 250mm | $8.50 |

# Running the console app #

Run the following from the command line while in the ParseTheParcel directory, passing in the dimensions and weight as command line arguments:
`dotnet run <length> <breadth> <height> <weight>`

# Running the tests #

Run the following from the command line while in the ParseTheParcel.Tests directory:
`dotnet test`
