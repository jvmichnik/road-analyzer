export function joinGroup(name) {
    return {
        type: 'GROUP_JOINED',
        payload: name
    }
}
export function leaveGroup(name) {
    return {
        type: 'GROUP_LEAVED',
        payload: name
    }
}