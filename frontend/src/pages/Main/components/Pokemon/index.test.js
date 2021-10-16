const rewire = require("rewire")
const index = rewire("./index")
const formatDescription = index.__get__("formatDescription")
// @ponicode
describe("formatDescription", () => {
    test("0", () => {
        let callFunction = () => {
            formatDescription(".\f\fNo description available.")
        }
    
        expect(callFunction).not.toThrow()
    })

    test("1", () => {
        let callFunction = () => {
            formatDescription("No description.")
        }
    
        expect(callFunction).not.toThrow()
    })

    test("2", () => {
        let callFunction = () => {
            formatDescription("Organize files in your directory instantly, .")
        }
    
        expect(callFunction).not.toThrow()
    })

    test("3", () => {
        let callFunction = () => {
            formatDescription("No description available.")
        }
    
        expect(callFunction).not.toThrow()
    })

    test("4", () => {
        let callFunction = () => {
            formatDescription("Print Base")
        }
    
        expect(callFunction).not.toThrow()
    })

    test("5", () => {
        let callFunction = () => {
            formatDescription(undefined)
        }
    
        expect(callFunction).not.toThrow()
    })
})
