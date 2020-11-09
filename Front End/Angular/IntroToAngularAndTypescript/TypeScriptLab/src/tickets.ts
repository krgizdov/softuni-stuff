class Ticket {
    constructor(public destination: string,
        public price: string, public status: string) { }
}

function getTickets(array: string[], criteria: string) {
    let tickets = convertTickets(array);

    sortTickets(tickets, criteria);

    return tickets;
}

function convertTickets(array: string[]) {
    let tickets: Ticket[] = [];

    array.forEach(e => {
        let splitLine = e.split("|");
        let destination = splitLine[0];
        let price = splitLine[1];
        let status = splitLine[2];
        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    });

    return tickets;
}

const sortMap = {
    ["destination"]: function (a: Ticket, b: Ticket) { return a.destination.toUpperCase() > b.destination.toUpperCase() ? 1 : -1 },
    ["price"]: function (a: Ticket, b: Ticket) { return +a.price > +b.price ? 1 : -1 },
    ["status"]: function (a: Ticket, b: Ticket) { return a.status.toUpperCase() > b.status.toUpperCase() ? 1 : -1 }
};

function sortTickets(tickets: Ticket[], criteria: string) {
    if (criteria === "destination") {
        tickets.sort(sortMap.destination);
    }
    else if (criteria === "price") {
        tickets.sort(sortMap.price);
    }
    else if (criteria === "status") {
        tickets.sort(sortMap.status);
    }
}

let tickets = getTickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], "destination"
);

console.log(tickets);