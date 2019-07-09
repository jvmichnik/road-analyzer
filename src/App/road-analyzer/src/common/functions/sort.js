export function sortListLevantamentos(a,b) {
    const first = a.end ? new Date(a.end) : new Date(1900,1,1)
    const second = b.end ? new Date(b.end) : new Date(1900,1,1)
    
    const value = first - second
    if(value === 0)
        return new Date(a.start) - new Date(b.start)
    
    return value
}