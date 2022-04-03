import { ApolloClient } from 'apollo-client';
import { SubscriptionClient } from 'subscriptions-transport-ws';

const graphqlSubscriptionEndpoint = `ws://localhost:8081/graphql`;

function connectToWebSocket() {
    // Create regular NetworkInterface by using apollo-client's API:
    //// Create WebSocket client
    const wsClient = new SubscriptionClient(`${graphqlSubscriptionEndpoint}`,
        {
            reconnect: true,
            connectionParams: { 
                // Pass any arguments you want for initialization
            }
        });
    const client = new ApolloClient({
	    networkInterface: wsClient
    });
    return client; 

}

function subscribe(client, gql, vars, callbackFun) {
    
    client.subscribe({
        query: Apollo.gql(gql),
        variables: vars
    }).subscribe({
        next(data) {
            // Notify your application with the new arrived data
            callbackFun(data);
        }
    });

}

const DETAILS_SHOWED = Apollo.gql(`subscription {detailsDisplayed {id} }`);


function callBackConnectDemo(data) {
    if (!!data && !!data.detailsDisplayed) {
	    toastr.info(`A user selected to display the mountain with ID: ${data.detailsDisplayed.id} `);
    }
}

var client = connectToWebSocket();

subscribe(client, DETAILS_SHOWED, {}, callBackConnectDemo);





//function createChild() {
//    var element = document.createElement('div');
//    element.innerHTML = _.join(['Hello', 'Webpack'], ' ');
//    return element;
//}
//document.body.appendChild(createChild());