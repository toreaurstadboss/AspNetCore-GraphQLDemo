import _ from 'lodash';
import { ApolloClient } from 'apollo-client';
import { SubscriptionClient } from 'subscriptions-transport-ws';


export function ConnectToWebSocket(url) {
    // Create regular NetworkInterface by using apollo-client's API:
   
    var GRAPHQL_SUBSCRIPTION_ENDPOINT = url;

    //// Create WebSocket client
    const wsClient = new SubscriptionClient(`${GRAPHQL_SUBSCRIPTION_ENDPOINT}`,
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

export function Subscribe(client, gqlInput, vars, callbackFun) {

     
    client.subscribe({
        query: Apollo.gql(gqlInput),
        variables: vars
    }).subscribe({
        next(data) {
            // Notify your application with the new arrived data
            callbackFun(data);
        }
    });

}


//expose methods to window object 

window.ConnectToWebSocket = ConnectToWebSocket;

window.Subscribe = Subscribe; 







//test code to check WebPack is working..

/*
function createChild() {
	var element = document.createElement('div');
	element.innerHTML = _.join(['Hello', 'Webpack'], ' ');
	return element;
}
document.body.appendChild(createChild());
*/




