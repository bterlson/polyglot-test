import { describe, it } from "node:test";
import assert from "node:assert/strict";
import { greet } from "../src/index.ts";

describe("greet", () => {
  it("returns expected message", () => {
    assert.equal(greet(), "Hello from TypeScript!");
  });
});
