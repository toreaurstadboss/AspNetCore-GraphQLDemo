import _ from 'lodash';
//import * as ConnectDemo from './apollo-subscribe'; 
import { ApolloClient, createNetworkInterface, gql } from 'apollo-client';
import { SubscriptionClient, addGraphQLSubscriptions } from 'subscriptions-transport-ws';


//import { SubscriptionClient, addGraphQLSubscriptions } from 'subscriptions-transport-ws';


function ConnectToWebSocket() {
    // Create regular NetworkInterface by using apollo-client's API:
   
    const GRAPHQL_ENDPOINT = `http://localhost:2542/graphql`;
    const GRAPHQL_SUBSCRIPTION_ENDPOINT = `ws://localhost:2542/graphql`;

    //// Create WebSocket client
    const wsClient = new SubscriptionClient(`${GRAPHQL_SUBSCRIPTION_ENDPOINT}`,
        {
            reconnect: true,
            connectionParams: {
                // Pass any arguments you want for initialization
            }
        });

    const networkInterface = createNetworkInterface({
	    uri: GRAPHQL_ENDPOINT,
	    opts: {
		    credentials: `same- origin`
	    },
    });

    //////// Extend the network interface with the WebSocket
    //const networkInterfaceWithSubscriptions = addGraphQLSubscriptions(
    //    networkInterface,
    //    wsClient
    //);

    const client = new ApolloClient({
	    networkInterface: wsClient
	    // …
    });

    return client;

}

function Subscribe(client, gql, vars, callbackFun) {

     
    client.subscribe({
        query: Apollo.gql`
   subscription {detailsDisplayed {id} }`,
        variables: vars
    }).subscribe({
        next(data) {
            // Notify your application with the new arrived data
            callbackFun(data);
        }
    });

}

function createChild() {
    var element = document.createElement('div');
    element.innerHTML = _.join(['Hello', 'Webpack'], ' ');
    return element;
}
document.body.appendChild(createChild());

const DETAILS_SHOWED = Apollo.gql(`subscription {detailsDisplayed {id} }`);


function callBackConnectDemo(data) {
    if (!!data && !!data.detailsDisplayed) {
	    toastr.info(`A user selected to display the mountain with ID: ${data.detailsDisplayed.id} `);
    }
}


var client = ConnectToWebSocket();

Subscribe(client, DETAILS_SHOWED, {}, callBackConnectDemo);


