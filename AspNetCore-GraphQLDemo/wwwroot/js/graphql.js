/**
 * Loads GraphQL data specified by query expression and passes the 'result' array to the callBackFunction
 * callBackFunction should be Js method (function) that accept one parameter, preferably called result, which is an object
 * that contains a result.data object.
 */
function LoadGraphQLData(gqlQuery, callBackFunction) {

	var apolloClient = new Apollo.lib.ApolloClient({
		networkInterface: Apollo.lib.createNetworkInterface({
			uri: 'http://localhost:2542/graphql',
			transportBatching: true,
		}), connectToDevTools: true
	});
	var query = Apollo.gql(gqlQuery);

	apolloClient.query({
		query: query,
		variables: {}
	}).then(result => {
		callBackFunction(result);
	}).catch(error => {
		//debugger
		toastr.error(error, 'GraphQL loading failed');
	});
}