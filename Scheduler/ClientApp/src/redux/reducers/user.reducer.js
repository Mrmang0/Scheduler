import {
	USER_LOGIN
} from "../actionsTypes/user.types"

export default function user(state = {}, action) {
	switch (action.type) {
		case USER_LOGIN:
			return ({
				name: "oba",
				email: "oba@cdm.dk",
			})
		default:
			return state
	}
}