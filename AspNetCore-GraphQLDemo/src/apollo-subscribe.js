////import { SubscriptionClient, addGraphQLSubscriptions } from 'subscriptions-transport-ws';
//import { ApolloClient, createNetworkInterface } from '@apollo/client';


//function ConnectToWebSocket() {
//// Create regular NetworkInterface by using apollo-client's API:
//	const networkInterface = createNetworkInterface({
//		uri: 'http://localhost:8081' // Your GraphQL endpoint
//	});

////// Create WebSocket client
////	const wsClient = new SubscriptionClient(`ws://localhost:2452/`,
////		{
////			reconnect: true,
////			connectionParams: {
////				// Pass any arguments you want for initialization
	
////			}
////		});

////// Extend the network interface with the WebSocket
////	const networkInterfaceWithSubscriptions = addGraphQLSubscriptions(
////		networkInterface,
////		wsClient
////	);

////// Finally, create your ApolloClient instance with the modified network interface
////	const apolloClient = new ApolloClient({
////		networkInterface: networkInterfaceWithSubscriptions
////	});
////	return apolloClient;
//}

//function Subscribe(client, gql, vars, callbackFun) {
//	client.subscribe({
//		query: gql`
//   subscription {detailsDisplayed {id} }`,
//		variables: vars
//	}).subscribe({
//		next(data) {
//			// Notify your application with the new arrived data
//			callbackFun(data);
//		}
//	});

//}

